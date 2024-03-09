import { ApiClient } from "@/services/api";
import { Button, MenuItem, Select, Stack, TextField } from "@mui/material";
import { useState } from "react";

export default function Home() {
  const [searchTerm, setSearchTerm] = useState('');
  const [searchType, setSearchType] = useState('');

  function executeSearch() {
    let apiClient = new ApiClient();

    return apiClient.getBooks(searchType, searchTerm);
  }

  return (
    <main className="flex flex-col items-center justify-between p-24">
      <Stack direction="row" justifyContent="flex-start" width="100%">
        <Select id="searchType" fullWidth placeholder="Select" value={searchType} onChange={() => setSearchType(s => s)} sx={{ mb: 2 }}>
          <MenuItem value="title">Title</MenuItem>
          <MenuItem value="author">Author</MenuItem>
          <MenuItem value="isbn">ISBN</MenuItem>
        </Select>

      </Stack>

      <Stack width="100%">
        <TextField id="searchTerm" value={searchTerm} fullWidth placeholder="Search" onChange={() => setSearchTerm(s => s)} />
      </Stack>

      <Stack width="100%">
        <Button sx={{ mt: 3, width: "48px", padding: 5 }} onClick={() => executeSearch()}>
          Search
        </Button>
      </Stack>
    </main>
  );
}
